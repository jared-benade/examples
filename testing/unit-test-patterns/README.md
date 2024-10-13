# Unit Test Patterns

## Test Data Builder
Test data builders are used for the creation of objects needed for tests. They generally use fluent syntax and have methods for setting single or multiple properties at once.

### When to use
- When you want to create similar objects with a standard set of default values.
- Since there are default values provided for an object's properties, you only need to setup the specific values that are relevant to the current test.
    - Doing this helps to improve the test's focus and readability and there will be less noise usually caused by mandatory (but not relevant to the current test) properties needing to be set.
- Methods can be setup that set values for multiple properties at once, in-line with a business rule (e.g.: setting up a specific user type in the domain).
    - This can help to fold business knowledge into your tests and can prevent tedious setup across multiple tests (if the same object scenario needs to be setup for each test).

### Drawbacks
- It takes effort to create builders, so it is generally something that should be refactored towards, instead of created off the get-go, before you know whether or not they are truly required.
- Overly generic builders can be challenging to work with and understand as it can be unclear as to where / how values are being set.

## Test Double
The term test double is the generic term used to describe any pretend object that is used in place of its real counterpart in testing. Stubs, mocks, fakes and spies are all test doubles.

## Stubs
A stub is an object setup to provide predefined/canned answers to specific calls. When using a stub, you will setup the answer you want returned for a specific method call, given a specific set of parameters.

### When to use
- Stubs are great to use when your current test relies on a value being returned by a dependency that cannot / is impractical to run normally (e.g.: a repository, an email service, etc).

### Drawbacks
- Since you are 'overriding' the behavior of an object (by telling it exactly what to return instead of letting it run its own computations), there could be undiscovered bugs due to the object behaving differently in production (compared to how you setup the scenario).

## Fakes
A fake is an object setup to have a working implementation that is different from what is in production. A fake will generally have a simpler implementation that takes shortcuts, compared to the production equivalent (e.g.: production repository will write to database and the corresponding fake will write to an in-memory list).

### When to use
- We can use fakes as lightweight implementations of dependencies for our SUT. For example, if we need a repository but haven't decided on a database technology, we can create a fake that implements an in-memory version of the interface (until we have made up our mind).  

### Drawbacks
- Fakes are only temporary implementations that will eventually need to be discarded, once we have decided on the final implementation. This effort could be wasteful if the fake is short lived or the usage of the dependency could have been deferred until the final implementation was decided upon.  

## Mocks
Mocks are objects setup with predefined expectations. If they receive a call that is different to what they expected, they can throw an exception, therefore failing the test. A mock is setup for a dependency of the SUT. 

### When to use
- When we want to assert that a dependency of the SUT is called with a specific set of parameters. Such a call might not have any visible side effects (e.g.: some service that calls an external API) and therefore would not be testable from the final output of the SUT call.

### Drawbacks
- With the assertion placed on the mock and not directly in the test, it can be a bit difficult to reason as to why the test is failing.

## Spies
Spies are objects setup to capture the inputs of a method call, on a dependency of the SUT.

### When to use
- Sometimes you need to know what a method has been called with (eg: knowing how many messages an email service as sent). A spy can be used to capture such information and make use of it as needed.
    - A spy is not used to verify that a method was called with a given parameter set. Such verification is done by a mock.

### Drawbacks
- A spy only records parts of the larger picture. Whilst this can sometimes be useful, it is usually better to focus on the entire process (ie: focus on the input and output and not be concerned by the smaller inner workings).