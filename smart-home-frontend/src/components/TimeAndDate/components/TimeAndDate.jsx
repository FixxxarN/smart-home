import React, { useState, useEffect } from "react";
import styled from "styled-components";

const StyledText = styled.p`
	color: #fff;
	margin: 0px;
`;

const StyledTimeAndDateContainer = styled.div`
	padding: 10px;
`;

const GetCurrentTime = () => {
	var date = new Date(parseInt(Date.now()));
	// Use localization here in the future
	return date.toLocaleTimeString("sv-SV", {
		hour: "2-digit",
		minute: "2-digit",
	});
};

const GetCurrentDate = () => {
	const options = {
		weekday: "long",
		year: "numeric",
		month: "long",
		day: "numeric",
	};
	// Use localization here in the future
	return new Date(Date.now())
		.toLocaleDateString("sv-SV", options)
		.toLocaleUpperCase();
};

const TimeAndDate = () => {
	const [time, setTime] = useState(GetCurrentTime());
	const [date, setDate] = useState(GetCurrentDate());

	setInterval(() => {
		setTime(GetCurrentTime());
	}, 1000);

	useEffect(() => {
		setDate(GetCurrentDate());
	}, [new Date(Date.now()).getDay()]);

	return (
		<StyledTimeAndDateContainer>
			<StyledText>{date}</StyledText>
			<StyledText>{time}</StyledText>
		</StyledTimeAndDateContainer>
	);
};

export default TimeAndDate;
