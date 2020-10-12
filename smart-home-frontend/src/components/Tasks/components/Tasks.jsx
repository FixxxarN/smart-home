import React, { useState } from "react";
import styled from "styled-components";

const StyledModuleContainer = styled.div`
	padding: 20px;
`;

const StyledContainer = styled.div`
	width: 200px;
`;

const StyledTasksContainer = styled.div`
	display: flex;
	flex-direction: column;
	color: #fff;
`;

const StyledHeader = styled.h2`
	color: #fff;
	margin: 0px;
`;

const Tasks = () => {
	const [tasks, setTasks] = useState([
		{ id: 1, text: "Vattna blommorna" },
		{ id: 2, text: "Slänga sopor" },
		{ id: 3, text: "Diska" },
	]);

	const RenderTasks = tasks.map((task, i) => {
		return (
			<>
				<div>
					<input
						type="checkbox"
						id={i}
						name={i}
						value={task.text}
						style={{ color: "#fff" }}
					></input>
					<label for={i} style={{ marginLeft: 10 }}>
						{task.text}
					</label>
				</div>
			</>
		);
	});

	return (
		<StyledModuleContainer>
			<StyledHeader>Dagens uppgifter</StyledHeader>
			<StyledContainer>
				<hr></hr>
				<StyledTasksContainer>{RenderTasks}</StyledTasksContainer>
			</StyledContainer>
		</StyledModuleContainer>
	);
};

export default Tasks;
