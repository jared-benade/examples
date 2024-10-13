# Single-Responsibility Principle

## Definition
Every software module should have only one reason to change.

## Examples

### Incorrect
Invoice handler handles extra responsibilities that are outside the scope of its main goal (ie: sending of emails and logging).

### Correct
An email client and logging handler have been separated out from the Invoice handler. Now the Invoice handler only has a single reason to change (ie: functionality around invoicing needs to be worked on).