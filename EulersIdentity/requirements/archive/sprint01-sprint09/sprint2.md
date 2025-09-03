# User stories - sprint 2

## 3.1 - WPF application to demonstrate the functionality of the PolynomialTerm, Polynomial and Equation classes

- As the developer of the EulersIdentity solution
- I want to create a WPF application
- So that I can use it to manually test the functionality of the PolynomialTerm, Polynomial and Equation classes
- Acceptance criteria
  - 1
    - Given I have a WPF application
    - When I run the application
    - Then it will follow the MVVM pattern
      - Any logic which needs to be in the UI rather than the core EulersIdentity project will be in the view model classes
      - Any models which are specific to the UI will contain no logic, only properties, and will be excluded from code coverage analysis
    - Then it will contain a TabControl with three tabs
	  - The first tab will be for creating and evaluating PolynomialTerm instances
	  - The second tab will be for creating and evaluating Polynomial instances
	  - The third tab will be for creating and manipulating Equation instances
    - Then the tabs will contain no child controls at this stage, as these will be added in subsequent user stories.
  - 2
    - Given I have a WPF application
    - When I want to unit test the functionality in the UI project
    - Then the unit tests will test the logic in the view model classes
    - Then the unit test coverage of the view model classes will be at least 90%
    - Then the unit tests will not attempt to test the UI itself, as this is not feasible with the current tools available
    - Then the unit tests for the UI project will use Moq to mock any dependencies on the core EulersIdentity project
    - Then the tests will not attempt to perform end to end testing of the UI using tools such as Selenium, SpecFlow and UIA

