import React, { useEffect, useState } from "react";
import styled from "styled-components";

const StyledText = styled.p`
	color: #fff;
`;

const Weather = () => {
	const [temp, setTemp] = useState("");

	const GetGeolocationAndFetchForWeatherData = () => {
		if (navigator.geolocation) {
			navigator.geolocation.getCurrentPosition((position) => {
				var lat = position.coords.latitude;
				var lon = position.coords.longitude;
				fetch(
					`https://api.weatherbit.io/v2.0/current?lat=${lat}&lon=${lon}&key=39771803801146b896455b73f8e36514`
				)
					.then((response) => response.json())
					.then((data) => {
						setTemp(data.data[0].temp);
					});
			});
		}
	};

	GetGeolocationAndFetchForWeatherData();

	return <StyledText>{temp}°</StyledText>;
};

export default Weather;
