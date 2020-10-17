import React, { useEffect, useState } from "react";
import { Weather } from "src/components/Weather";
import { TimeAndDate } from "src/components/TimeAndDate";
import { useHubConnection } from "src/hooks";
import { Tasks } from "src/components/Tasks";
import { Events } from "src/components/Events";
import { Quotes } from 'src/components/Quotes';

const Home = () => {
	const [name, setName] = useState("");

	useEffect(() => {
		const connect = () => {
			const hubConnection = useHubConnection(
				"http://192.168.1.33:9999/smart-home-backend/"
			);

			hubConnection.on("SendPersonData", ({ id, name, age, birthday }) => {
				setName(name);
			});
		};

		connect();
	}, []);

	return (
		<>
			<TimeAndDate />
			<Weather />
			{/* <p style={{ color: "#fff" }}>Name: {name}</p> */}
			<Tasks />
			<Events />
			<Quotes />
		</>
	);
};

export default Home;
