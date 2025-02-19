﻿CREATE PROCEDURE [dbo].[Lookup_Txn_GetByCustomerId]
	@CustomerId varchar(21)
AS
SET NOCOUNT ON
BEGIN
	SELECT [TXN_ID]
      ,[AGREEMENT_ID]
      ,[CUSTOMER_ID]
      ,[BANK_ID]
      ,[TXN_CODE]
      ,[TXN_DATE]
      ,[TXN_AMOUNT]
      ,[TXN_TEXT]
      ,[CURRENCY_CODE]
      ,[TXN_CUR_AMOUNT]
      ,[TXN_CORR_ACCOUNT]
      ,[TXN_CORR_NAME]
      ,[TXN_CORR_BANK]
      ,[TXN_CORR_COUNTRY]
      ,[CUSTOMER_SEGMENT]
      ,[CUSTOMER_TYPE]
      ,[SALARY_FLAG]
      ,[PRODUCT_ID]
  FROM [dbo].[TXN]
  WHERE [CUSTOMER_ID] = @CustomerId
  ORDER BY [TXN_ID]
END
