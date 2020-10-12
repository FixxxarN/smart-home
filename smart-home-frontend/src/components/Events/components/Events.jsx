import React, { useState } from "react";
import styled from "styled-components";

const StyledModuleContainer = styled.div`
	padding: 20px;
`;

const StyledContainer = styled.div`
	width: 200px;
`;

const StyledEventsContainer = styled.div`
	display: flex;
	flex-direction: column;
	color: #fff;
`;

const StyledHeader = styled.h2`
	color: #fff;
	margin: 0px;
`;

const Events = () => {
	const [events, setEvents] = useState([
		{ id: 1, time: "13:00", text: "Möte med chefen" },
		{ id: 2, time: "17:00", text: "Kalas" },
	]);

	const RenderEvents = events.map((event, i) => {
		return (
			<>
				<div>
					<p style={{ margin: 0 }}>
						{event.time} | {event.text}
					</p>
				</div>
			</>
		);
	});

	return (
		<StyledModuleContainer>
			<StyledHeader>Dagens händelser</StyledHeader>
			<StyledContainer>
				<hr></hr>
				<StyledEventsContainer>{RenderEvents}</StyledEventsContainer>
			</StyledContainer>
		</StyledModuleContainer>
	);
};

export default Events;
