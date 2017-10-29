# Hosted Link
http://ec2-54-252-243-233.ap-southeast-2.compute.amazonaws.com/

# Code Structure

## Web API
Web API code is structured under [Backend](https://github.com/techchallenge-droy/techchallenge_debojitroy/tree/master/BackendWebAPI/WilliamHillTechChallenge)

## Front End
Front End Code is structured under [FrontendWebsite](https://github.com/techchallenge-droy/techchallenge_debojitroy/tree/master/FrontEndWebsite)

## Deployment 
[Deployment folder](https://github.com/techchallenge-droy/techchallenge_debojitroy/tree/master/Deployment) contains the optimized, release build which can be deployed on the server.


# Web API
Web API is build using ASP.NET WebAPI 2, on VS Studio 2017 and pointing to .NET framework 4.6.2. The code is split between DAO, Provider and Web API Controllers. 

* **DAO** is responsible for interacting with the persistent or backend stores and fetch the data

* **Provider** is responsible for the business Logic

* **Web API** contains the actual controllers

To run the application, Launch the ``RaceDay.WebApi`` Project in debug mode. 

# Front End Website

Front end is built using React. The bootstrapping of the project is done [create-react-app](https://github.com/facebookincubator/create-react-app). The website is responsive and the cards adjust based on the screen width.

To install pacakges, run
    ``yarn install`` or ``npm install``
    
To start the front end application, run ``yarn start`` or ``npm run start``

# Hosting

## Creating Deployment from source

* Go to the frontend website folder
* Run ``yarn build`` or ``npm run build``
* Copy the contents of the ``build`` folder to the hosting folder of IIS.
* Go to the Web API Project
* Right click on the project and select ``Publish`` and ``Publish to Folder`` in the next options.
* Once ``Web API`` is published, go to ``IIS Management Console``
* Change the binding of ``Default Website`` to output folder of Front end Website ``build`` folder.
* Add ``New Application`` to the ``Default Website``
* Name the Application as ``api`` and bind it to the publish folder of Web API.
* Select ``Application Pool`` of ``.NET 4.5``
* Save the settings and restart the website.
* Browse to the ``Default Website`` and the dashboard should be loaded.

## Using the Deployment Folder

* Change the binding of ``Default Website`` to output folder of Front end Website ``Deployment\website`` folder.
* Add ``New Application`` to the ``Default Website``
* Name the Application as ``api`` and bind it to the ``Deployment\api``.
* Select ``Application Pool`` of ``.NET 4.5``
* Save the settings and restart the website.
* Browse to the ``Default Website`` and the dashboard should be loaded.
