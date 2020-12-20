﻿CREATE TABLE [dbo].[AGREEMENTS] (
    [AGREEMENT_ID]           VARCHAR (21)    NOT NULL,
    [CUSTOMER_ID]            VARCHAR (21)    NULL,
    [BANK_ID]                CHAR (5)        NULL,
    [PRODUCT_ID]             VARCHAR (16)    NULL,
    [AGRMT_BALANCE]          NUMERIC (15, 2) NULL,
    [AGRMT_OPEN_DATE]        DATE            NULL,
    [AGRMT_CLOSE_DATE]       DATE            NULL,
    [AGRMT_AMOUNT]           NUMERIC (15, 2) NULL,
    [LAST_PMNT_DATE]         DATETIME        NULL,
    [NEXT_PMNT_DATE]         DATETIME        NULL,
    [AGRMT_PMNT_TYPE]        VARCHAR (10)    NULL,
    [AGRMT_LIMIT]            NUMERIC (15, 2) NULL,
    [AGRMT_ABW_OBJ_TYP_SCHL] VARCHAR (4)     NULL,
    [AGRMT_ABW_OBJ_ID]       VARCHAR (32)    NULL,
    [AGRMT_ABW_OBJ_WHG_SCHL] VARCHAR (4)     NULL,
    [AGRMT_STATUS]           VARCHAR (4)     NULL,

  CONSTRAINT [PK_AGREEMENTS] PRIMARY KEY CLUSTERED ([AGREEMENT_ID] ASC))