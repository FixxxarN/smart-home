import React from 'react';
import styled from 'styled-components';

const StyledQuotesContainer = styled.div`
    padding: 20px;
`;

const StyledQuotesText = styled.p`
    margin: 0;
    color: #fff;
    font-style: italic;
`;

const StyledHeader = styled.h2`
	color: #fff;
	margin: 0px;
`;

const StyledContainer = styled.div`
	width: 200px;
`;

const Quotes = () => {
    return(
    <>
        <StyledQuotesContainer>
            <StyledHeader>Dagens citat</StyledHeader>
            <StyledContainer>
                <hr></hr>
                <StyledQuotesText>
                    “The secret of getting ahead is getting started.” – Mark Twain.
                </StyledQuotesText>
            </StyledContainer>
        </StyledQuotesContainer>
    </>);
};

export default Quotes;