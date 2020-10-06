import React from "react";
import { Weather } from "src/components/Weather";
import { TimeAndDate } from "src/components/TimeAndDate";

const Home = () => {
	return (
		<>
			<Weather />
			<TimeAndDate />
		</>
	);
};

export default Home;
