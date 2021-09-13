Snowflake Database connector for the OutSystems Platform.

This is a project built with the OutSystems Database Connector SDK and allows you to integrate with a Snowflake database in your OutSystems Platform as easily as you can with the built-in database connectors.

This connector is only compatible with and OutSystems Enterprise OnPremises installation.

This is a personal project, not supported by OutSystems.

Building the Package
====================

Prerequisites
-------------

This project is developed under Visual Studio 2019. All other versions of Visual Studio are not supported.

How To Install:
-----

1) Stop your OutSystems Services
2) Copy the generated SnowflakeDatabaseProvider.dll and Snowflake.Data.dll to <your OutSystems Installation Path>\Platform Server\plugins\database
3) Make sure to open properties and Unblock the DLLs if they are blocked
4) Restart all OutSystems Services
4) Open the OutSystems Configuration Tool
5) Run Configuration Tool and install Service Center
6) If you have any application that uses the connector, publish it again.

Dependencies
=====================

The lastest version uses the Snowflake .NET driver (https://github.com/snowflakedb/snowflake-connector-net). However due to the way the drive works it was necessary to make a couple of changes.

Snowflake.Data/Core/HttpUtil.cs
-----

The original method uses code that is not compatible with .net standard 2.0 and only .net 4.7.2. The connector when uses in an espace runs in the context of .net 4.7.2 (or higher) which is fine but the test query runs in the context of the OutSystems compiler service which is .net standard and fails. For that reason we use an old method of enforcing Tls 1.2 and CheckCertificateRevocationList.

* **Before**

    ```cs
    private HttpClientHandler setupCustomHttpHandler(HttpClientConfig config)
	{
		HttpClientHandler httpHandler = new HttpClientHandler()
		{
			// Verify no certificates have been revoked
			CheckCertificateRevocationList = config.CrlCheckEnabled,
			// Enforce tls v1.2
			SslProtocols = SslProtocols.Tls12,
			AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
			UseCookies = false // Disable cookies
		};
		(...)
	}
    ```
	
* **After**

    ```cs
    private HttpClientHandler setupCustomHttpHandler(HttpClientConfig config)
	{
		HttpClientHandler httpHandler;

		try
		{
			httpHandler = new HttpClientHandler()
			{
				// Verify no certificates have been revoked
				CheckCertificateRevocationList = config.CrlCheckEnabled,
				//Enforce tls v1.2
				SslProtocols = SslProtocols.Tls12,
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
				UseCookies = false // Disable cookies
			};
		} catch {
			httpHandler = new HttpClientHandler()
			{
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
				UseCookies = false // Disable cookies
			};

			ServicePointManager.CheckCertificateRevocationList = config.CrlCheckEnabled;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		}
		(...)
	}
    ```
	
	
Snowflake.Data/Core/SFDataConverter.cs
-----

The original method for the snowflake datatype TIMESTAMP_NZ, the driver returns a DateTimeOffset. However this object does not implement the IConvertible interface and fails on parse and for that reason we extract the datetime from the object.

* **Before**

    ```cs
    internal static object ConvertToCSharpVal(UTF8Buffer srcVal, SFDataType srcType, Type destType)
	{
		try
        {
			// The most common conversions are checked first for maximum performance
			(...)
			else if (destType == typeof(DateTimeOffset))
			{
				return ConvertToDateTimeOffset(srcVal, srcType).DateTime;
			}
			(...)
	}
    ```
	
* **After**

    ```cs
    internal static object ConvertToCSharpVal(UTF8Buffer srcVal, SFDataType srcType, Type destType)
	{
		try
        {
			// The most common conversions are checked first for maximum performance
			(...)
			else if (destType == typeof(DateTimeOffset))
			{
				return ConvertToDateTimeOffset(srcVal, srcType).;
			}
			(...)
	}
    ```

Dependencies
-----

The dependencies have been downgraded to match the ones used by the OutSystems Platform (11.11.3+) and the dlls have been combined into a single package excluding the ones already present in any OutSystems installation.
