# Javascript Object Creation Patterns

## Object Literals
This is the simplest form of object creation and is the standard Javascript approach to creating objects.

### When to use
- Good for when you want a single object to be created without the need to create duplicates in the future (a one off operation)

### Drawbacks
- If you need to create the same object in multiple places, you will need to copy-paste the object. This leads to code duplication, making future maintainability more challenging.

## Factory pattern
This pattern allows for the creation of multiple copies of the same object literal by abstracting away and encapsulating the logic required to create a specific object.

### When to use
- If the same object needs to be created multiple times (possibly in multiple locations), then the logic required for the object creation can be centralized within a single function.
    - Parameters can be set on the factory function to set specific properties on the object that will be created.

### Drawbacks
- Since each object that is created is an entire instance of the object (including unique copies of the various functions on the object), you can quickly cause memory bloat (since the same function implementation is stored in memory for each new instance you create),

## Constructor pattern
This pattern is very similar to the Factory Pattern, but instead of first internally creating a new object and assigning values to its properties, this pattern assigns the properties and functions of the object directly to the `this` object inside the function. The `new` keyword must now be used when calling the constructor.

### When to use
- This pattern works well when creating a specific instance of an object (i.e.: you don't want to create variants of an object based off some supplied property / condition).

### Drawbacks
- Before ES6, you could forget to supply the `new` keyword and no error would be thrown. If this mistake is made, the various properties you assign within the constructor will not be set on the newly created object, but rather 
the global `this` context (the returned object will be undefined and you will have polluted the global space). Since ES6, if the `new` keyword is left out, an error will be thrown.

## Prototype pattern
With this pattern, we create an empty object and assign properties / functions to the prototype of that object. When creating the object, default values are initially set on the prototype and then (after object creation) values can be specifically set as needed. 

### When to use
- This pattern helps to reduce the memory footprint of object creation since default values and functions are not duplicated across the various objects, but are rather associated with the shared, underlying prototype object.

### Drawbacks
- There can be some unexpected behavior with using certain functions and interactions. Since the values and functions set are stored on the prototype, a call to a function such as `hasOwnProperty` (which only checks the root elements of the object) can cause bugs since at runtime the properties are in place but not in the expected location.

## Dynamic prototype pattern
This is a hybrid of the prototype and constructor patterns. Properties are assigned to the newly created object itself (instead of to the prototype) and functions are still assigned to the prototype.  

### When to use
- If a large number of objects are being created, this pattern can give you the benefits of supplying specific property overrides as well as setting the implementation of functions to the prototype thus saving on the memory footprint. 

### Drawbacks
- Since the properties are stored on the object itself now, if the values rarely change then this pattern wastes memory by having the same property values duplicated for each created object (as opposed to living on the shared prototype object).
- This pattern breaks the Single Responsibility Principle as values are being set on both the instance and prototype in a single function call (i.e.: the constructor).
- Trying to access the prototype before initializing the object will result in the prototype not having values set, which could cause bugs in the calling code.

## Builder
This pattern allows the building of objects using a fluent syntax (i.e.: chained function calls) in which properties are assigned through function calls available on the builder object. The builder object normally instantiates an object (the one that will be build up) with some default values and then exposes functions that will either set individual properties or a collection of properties (generally these properties are grouped together logically by a business rule or concept). After setting the various properties required, you would call a `build` function on the builder to return the built object.  

### When to use
- This pattern is great for tests as only the properties required for the test in question need to be set (other properties can be left with their default values).

### Drawbacks
- Builders can be made overly generic and can be quite difficult to understand if over-engineered.
- Creating builders can be a costly exercise and therefore it is generally a good practice to use a simpler pattern first and refactor towards a builder.