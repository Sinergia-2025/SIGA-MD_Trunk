/****** Script for SelectTopNRows command from SSMS  ******/
SELECT
        [name]
       ,create_date
       ,modify_date
FROM
        sys.tables
        order by modify_date desc