﻿USE [C:\USERS\JAYMIN\DOWNLOADS\NEXGENMVC-MASTER(1)\NEXGENMVC-MASTER\NEXGENMVC\APP_DATA\DEFAULTCONNECTION.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Procedure]
		@param2 = NULL

SELECT	@return_value as 'Return Value'

GO
