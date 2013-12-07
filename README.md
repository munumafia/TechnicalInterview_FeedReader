Super Simple News Reader
=============================
This is a very simple news reader written using jQuery, AJAX, ASP.NET MVC and Web API 2.0. As of now, it 
supports two different syndication formations: RSS and Atom. Super Simple News Reader will automatically detect which 
feed format you are trying to subscribe to and automatically do the right thing.

Installation Instructions
---------------------------------

You'll need to first need to create the database. You'll need to update the connection strings in the app.config file 
in the TechnicalInterviewer\_FeedReader.Data project and in the web.config file in the TechnicalInterview\_FeedReader 
project to point to the SQL database you want to use.

The next step is to open up the package manager console in Visual Studio and populate the database. Make sure that 
the TechnicalInterview\_FeedReader.Data project is selected as the default project in the package manager console, 
then execute the command "Update-Database" to run all the database migrations.

Demo Version
--------------------

I have a set up a [demo version](http://feedreader.azurewebsites.net) of the website on Windows Azure if you want 
to check out the project without having to go through the trouble of setting up the website. 
