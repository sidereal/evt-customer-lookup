﻿CREATE PROCEDURE [dbo].[Lookup_Statistics05_GetByCustomerId]
	@CustomerId varchar(21)
AS
SET NOCOUNT ON
BEGIN
   SELECT [STATS_EVT05_ID] as STATS_ID
      ,[CUSTOMER_ID]
      ,[YEAR_]
      ,[MONTH_]
      ,[MAX_AMOUNT]
      ,[DATE_MAX]
      ,[SEC_AMOUNT]
      ,[DATE_SEC]
      ,[LAST_DATE]
      ,[FIXED_DATE]
      ,[EVENT_ID]
  FROM [dbo].[STATISTICS_EVENT05]
  WHERE [CUSTOMER_ID] = @CustomerId
END
