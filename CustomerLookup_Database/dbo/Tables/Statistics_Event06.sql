﻿CREATE TABLE [dbo].[STATISTICS_EVENT06](
	[STATS_EVT06_ID] [numeric](38, 0) IDENTITY(1,1) NOT NULL,
	[CUSTOMER_ID] [varchar](21) NULL,
	[YEAR_] [numeric](38, 0) NOT NULL,
	[MONTH_] [numeric](38, 0) NOT NULL,
	[MAX_AMOUNT] [numeric](18, 2) NULL,
	[DATE_MAX] [date] NULL,
	[SEC_AMOUNT] [numeric](18, 2) NULL,
	[DATE_SEC] [date] NULL,
	[LAST_DATE] [date] NULL,
	[FIXED_DATE] [date] NULL,
	[EVENT_ID] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_STATS_EVENT06] PRIMARY KEY CLUSTERED  ([STATS_EVT06_ID] ASC))
