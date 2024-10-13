# Asynchronous Programming

## The Basics

### What is it?

Asynchronous programming is a form of parallel programming in which a unit of work runs separately from the main application thread. Once the unit of work has completed it notifies the main application that its work is done (and whether the work was completed successfully or there was a failure).

### Why use it?

Asynchronous programming allows for multiple independent sub-requests to be processed in parallel. This can result in a performance increase as the sub-requests (which do not rely on input from each other) can be run at the same time, therefore reducing the overall wait time for the overarching request.

### When not to use it?

Since asynchronous operations happen independently from one another, they have no knowledge of each others state or interactions. This lack of awareness can lead to possible deadlocks or race conditions. 

- A deadlock can occur if separate asynchronous operations are waiting on each other to finish before they can proceed.
    - An example of this would be two operations that each lock a variable that the other needs and will only release the variable upon completion. Each operation will then wait until the required resource is free, but since neither variable is being released until completion (by the other operation), a stalemate ensues and the system locks up indefinitely.

- A race condition occurs when separate asynchronous operations have access to the same shared data and both work to update this data. The data can end up in an unintended / corrupted state due to the order of execution between the different operations being unpredictable (there is generally no way to guarantee which changes will be applied first).
    - An example of this would be two operations that both try to update the same record in the database. The state of the record in question will depend entirely upon which operation executed last (which in this scenario is unknown until it actually occurs)
      
## Types of Asynchronous Operations

### Blocking

With this type of call, control of the main thread is not returned (i.e.: it is blocked) until the asynchronous operation has completed. This is very similar to a synchronous operation in which nothing else can occur on the calling thread until a task has completed.

This is the standard type of call for operations that are short lived (such as quick computations), if nothing needs to be done in parallel or if there is no need to return control to calling thread (e.g.: there is no UI thread that would be perceived as "hanging")

### Non Blocking

With this type of call, control of the main thread is returned and the operation will continue to occur in the background. The main thread will frequently check on the status of the asynchronous operation to see if there has been a conclusion (with either a success or failure).

The thread that the asynchronous operation started on will not be made available to the thread pool until the operation has completed, even if it is sitting idle (waiting for some process to complete). This means that in a busy environment (such as a server with a large number of incoming calls) the thread pool can quickly be depleted if multiple long running requests are made that do not require actual computation (such as a request to the database).

This type of call is appropriate if multiple operations (that do not rely on each other) can occur in parallel and do not require large amounts of idle time (e.g.: are relatively quick computations). This is also preferred over a blocking call if the calling thread is the UI (as we don't want the UI to appear frozen or unresponsive while we are waiting for the result of the asynchronous operation).

### Async / Await

This type of call is similar to a non blocking call, but instead of the calling thread checking if the asynchronous operation has completed, that work is delegated and therefore the calling thread will only hear about the asynchronous operation again once it has completed (with either a success or failure).

With this type of call, the calling thread will be released back into the thread pool whilst the asynchronous operation is sitting idly waiting for a result (e.g.: a result from a remote database query). This reuse of threads makes for the most responsive user experience (from both UI responsiveness and server queue time) as using new threads for the various asynchronous tasks does not scale well (there is only ever a finite number of threads in the pool).

Async / Await is the preferred style of asynchronous programming as it improves the user's experience (with the focus on responsiveness) and makes better use of system resources, improving overall scalability (particularly important for usage in a server environment).

## Async / Await Under The Hood

Coming soon... (working on finding a way to easily explain the created state machine)

## Cancellation Tokens

A cancellation token is a class that is used to request the cancellation of a task. The calling thread does not force the task in question to end but does signal that a cancellation has been requested. If the task in question has not started processing as yet, the task object will automatically transition to a cancelled state and no processing will occur. However, if the task is already running, it will be up to task as to how it handles the cancellation request.

A common use-case for cancellation tokens is to prevent unnecessary processing (and therefore wasted resource usage) on an API. If the user makes an  API request and then navigates away, changes filters, etc, a cancellation request can be sent to the API method currently in flight so that the processing can be abandoned and the server's resources can be freed up.