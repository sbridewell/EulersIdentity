# Backlog - Euler's Identity

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

## 3.3 - Implement and test the functionality for creating and evaluating polynomials (needs extra info).

- As a developer with an interest in maths,
- I want to create instances of the Polynomial class, add terms to it, and evaluate it for given values of x,
- So that I can verify the correctness of polynomial expressions.
- Acceptance Criteria:
  - Given I have a WPF application
  - When I run the application
  - Then I can create an instance of the Polynomial class.
  - Then I can add instances of PolynomialTerm to the polynomial.
  - Then I can evaluate the polynomial for a given value of x.
  - Then I can view a string representation of the polynomial.
  - Then I can do this in the Polynomial tab of the Windows Forms application.
  - Then the UI functionality will be implemented in a user control which can be reused in the Equation tab.
  - Then the UI will allow me to add and remove terms from the polynomial by clicking buttons.
  - Then the evaluation result will be displayed in a label.

## 3.4 - Implement and test operations on polynomials (needs extra info).

- As a developer with an interest in maths,
- I want to perform operations such as addition, subtraction, multiplication, and division on polynomials,
- So that I can manipulate polynomial expressions.
- Acceptance Criteria:
  - Given I have a WPF application
  - When I run the application
  - Then I can add, subtract, multiply, and divide polynomials by individual terms.
  - Then I can add, subtract, multiply, and divide polynomials by other polynomials.
  - Then I can simplify the polynomial by removing terms with near-zero coefficients.

## 3.5 - Implement and test the functionality for creating and simplifying equations (needs extra info).

- As a developer with an interest in maths,
- I want to create instances of the Equation class and simplify equations by performing operations on both sides,
- So that I can verify the correctness of equations.
- Acceptance Criteria:
  - Given I have a WPF application
  - When I run the application
  - Then I can create an instance of the Equation class with polynomial expressions on both sides.
  - Then I can perform operations (addition, subtraction, multiplication, division) on both sides of the equation.
  - Then I can simplify the equation by performing the same operation on both sides.
  - Then I can view a string representation of the equation in the format left = right.
