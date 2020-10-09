import { useEffect } from "react";
import * as signalR from "@aspnet/signalr";

let hubConnection;

const startConnection = () => {
	const maxRetries = 5;
	let error;
	for (let i = 0; i <= maxRetries; i++) {
		try {
			return hubConnection.start();
		} catch (e) {
			error = e;
		}
	}
	throw error(`Failed to connect to server. Error message: ${error}`);
};

const connect = () => {
	try {
		return startConnection();
	} catch (error) {
		console.log(error);
	}
};

export const useHubConnection = (url) => {
	const endpoint = url + "hub/";

	if (!hubConnection) {
		hubConnection = new signalR.HubConnectionBuilder()
			.withUrl(endpoint, { "content-type": "application/json" })
			.build();

		hubConnection.onclose(() => {
			connect();
		});

		connect();
	}
	return hubConnection;
};
