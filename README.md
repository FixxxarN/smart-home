# smart-home
# Introduction
The smart-home will consist of three projects, a frontend (React.js, "smart-home-frontend"), a backend (.NET Core, "smart-home-backend") and a facial recognition project (python, "smart-home-facial-recognizer"). As a first prototype the smart-home will be a "Smart Mirror" that will consist of a frame, a two-way mirror, a TV, a Raspberry PI and a Raspberry PI Camera v2.  

The frontend and the backend will be hosted locally on an IIS server on my PC. The frontend will be rendered on the TV through the Raspberry PI and connected to the backend through signalR. The opencv part will be used from the Raspberry PI through CLI and will send data to the backend via REST API.
