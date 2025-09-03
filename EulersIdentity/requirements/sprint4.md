# User stories - sprint 4

## 3.3 - Implement and test the functionality for creating and evaluating polynomials (needs extra info).

- As a developer with an interest in maths,
- I want to create instances of the Polynomial class, add terms to it, and evaluate it for given values of x,
- So that I can verify the correctness of polynomial expressions.
- Acceptance Criteria:
  - 1
	- Given I have a WPF application
	- When I run the application
	- Then I can create an instance of the Polynomial class.
	- Then I can add instances of PolynomialTerm to the polynomial.
	- Then I can view a string representation of the polynomial in a label.
	  - The terms of the polynomial will be displayed in descending order of exponent.
	- Then I can do this in the Polynomial tab of the Windows Forms application.
	- Then the UI functionality will be implemented in a user control which can be reused in the Equation tab.
	- Then the UI will allow me to add and remove terms from the polynomial by clicking buttons.
	- Then I can enter a value of x into a text box.
	- Then I can evaluate the polynomial for the entered value of x.
	- Then the evaluation result will be displayed in a label.
  - 2
    - Given a PolynomialTermControl user control has already been implemented
    - When the user interacts with the PolynomialControl
    - Then the functionality implemented in the PolynomialTermControl user control to edit and validate polynomial terms will be reused in the PolynomialControl user control
      - The PolynomialControl user control will allow the user to add and remove PolynomialTermControl user controls to edit multiple polynomial terms
    - Then the state of the PolynomialTermControl will be preserved when switching between tabs

