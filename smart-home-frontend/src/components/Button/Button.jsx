import React from "react";
import styled from "styled-components";
import PropTypes from "prop-types";

const StyledButton = styled.button`
	width: 100px;
	height: 20px;
`;

const Button = ({ text }) => {
	return <StyledButton>{text}</StyledButton>;
};

Button.propTypes = {
	text: PropTypes.string,
};

export default Button;
