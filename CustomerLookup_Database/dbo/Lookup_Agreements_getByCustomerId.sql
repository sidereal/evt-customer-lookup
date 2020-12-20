CREATE PROCEDURE [dbo].[Lookup_Agreements_GetByCustomerId]
	@CustomerId varchar(21)
AS
SET NOCOUNT ON
BEGIN
    SELECT [AGREEMENT_ID]
      ,[CUSTOMER_ID]
      ,[BANK_ID]
      ,[PRODUCT_ID]
      ,[AGRMT_BALANCE]
      ,[AGRMT_OPEN_DATE]
      ,[AGRMT_CLOSE_DATE]
      ,[AGRMT_AMOUNT]
      ,[LAST_PMNT_DATE]
      ,[NEXT_PMNT_DATE]
      ,[AGRMT_PMNT_TYPE]
      ,[AGRMT_LIMIT]
      ,[AGRMT_ABW_OBJ_TYP_SCHL]
      ,[AGRMT_ABW_OBJ_ID]
      ,[AGRMT_ABW_OBJ_WHG_SCHL]
      ,[AGRMT_STATUS]
  FROM [dbo].[AGREEMENTS]
  WHERE [CUSTOMER_ID] = @CustomerId
END
