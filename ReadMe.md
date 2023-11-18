TAL Premium Calculator v1.0

Instructions:
==========================================
1. Rstore the backup 'TAL.bak' in SQL Server.
2. Alternatively, instead of restoring the backup, please run the following scripts sequentially to create database, tables and insert data:
	a. Run 'TAL_Database_Script.sql'
	b. Run 'TAL_Create_tblRating.sql'
	c. Run 'TAL_Create_tblOccupation.sql'
	d. Run 'TAL_InsertData.sql'
3. Change the connection string in the application configuration file in the API layer.
4. Set the following two projects as startup:
	* TALWebAPI
	* TALWebSiteDotNet
5. Run the projects.