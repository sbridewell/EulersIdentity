# User stories - Sprint 3

## 3.2 - Implement and test the functionality for creating and evaluating polynomial terms (ready).

- As a developer with an interest in maths,
- I want to create instances of the PolynomialTerm class and evaluate them for given values of x,
- So that I can verify the correctness of individual polynomial terms.
- Acceptance Criteria:
  - Given I have a WPF application
  - When I run the application
  - Then I can create instances of the PolynomialTerm class with a coefficient and an exponent.
  - Then I can evaluate a polynomial term for a given value of x.
  - Then I can view a string representation of the term in the format cx^e.
  - Then I can do this in the PolynomialTerm tab of the WPF application.
  - Then The UI functionality will be implemented in a user control which can be reused in the Polynomial and Equation tabs.
  - Then the coefficient and exponent can be entered into text boxes
  - Then the evaluation result will be displayed in a label
  - Then the coefficient and exponent text boxes will have validation to ensure they contain valid numeric values, which can be positive or negative, integer or decimal
    - If the input is invalid, an error message will be displayed in a label control and the user will not be able to move the focus to a different control until the input is valid
    - If the input is invalid, the invalid value will not be changed by the application, only by the user
    - If the input is valid, any error message will be cleared and the user will be able to move the focus to a different control

