import React, { useEffect, useState } from "react";
import styled from "styled-components";
import CloudIcon from "@material-ui/icons/Cloud";
import SvgIcon from "@material-ui/core/SvgIcon";

const StyledText = styled.p`
	color: #fff;
	margin: 5px;
`;

const StyledWeatherContainer = styled.div`
	display: flex;
	padding: 10px;
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

	return (
		<>
			<StyledWeatherContainer>
				<StyledText>{temp}°</StyledText>
				<SvgIcon htmlColor="#fff">
					<CloudIcon />
				</SvgIcon>
			</StyledWeatherContainer>
		</>
	);
};

export default Weather;
