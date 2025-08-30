# User stories - sprint 1

## 1 - represent a polynomial expression as a class

- As a developer with an interest in maths
- I want to represent a polynomial expression with non-integer exponents as a class which implements the IPolynomial interface
- So that I can manipulate and evaluate polynomial expressions programmatically
- Acceptance criteria
  - 1
	- Given I have a polynomial expression like `3x^2 + 2x + 1`
	- When I create an instance of the Polynomial class with this expression
	- Then I can evaluate the polynomial for a given value of `x`
  - 2
    - Given I have a polynomial expression with non-integer exponents like `2x^1.5 + 3x^0.5`
	- When I create an instance of the Polynomial class with this expression
	- Then I can evaluate the polynomial for a given value of `x`
  - 3
    - Given I want to represent a polynomial expression in code
    - When I instantiate an instance of the Polynomial class with a polynomial expression
    - Then I will do so by creating an instance of the PolynomialTerm for each term in the polynomial
    - And I will create a default instance of the Polynomial class with no terms
    - And I will pass each of the terms to its Add method to set its terms
    - And I will not need to attempt to create an instance of the PolynomialTerm class by parsing a string representation of the polynomial expression

## 2 - build and manipulate equations with polynomial expressions

- As a developer with an interest in maths
- I want to represent equations with polynomial expressions on both sides as a class which implements the IEquation interface
- So that I can manipulate and solve these equations programmatically
- Acceptance criteria 
  - 1
    - Given I have an equation with polynomial expressions on both sides like `3x^2 + 2x + 1 = 2x^2 + 1`
    - When I create instances of the Polynomial class for both sides of the equation
    - Then I can manipulate the equation to find the value of `x` that satisfies the equation
  - 2
	- Given I have an equation with polynomial expressions involving multiple variables like `3x^2 + 2x + 1 = 2x^2 + x`
	- When I run the console application
	- Then I can display the polynomial expressions in the format `3x^2 + 2x + 1 = 2x^2 + x`
	- And I can manipulate the equation to find the values of `x` that satisfies the equation
  - 3
    - Given I want to represent an equation in code
    - When I instantiate an instance of the Equation class with a polynomial expression on both sides
    - Then I will do so by creating instances of the Polynomial class for each side of the equation
    - And I will pass both polynomial expressions to the Equation constructor
    - And I will not need to attempt to create an instance of the Polynomial class by parsing a string representation of the equation

