# Test of speed of DI Containers

Attempting to test the speed of various Dependency Injection Containers.

See the results of my tests here: http://philipm.at/2011/0808/

.Net Containers:

- Autofac
- Castle.Windsor
- ninject 
- Spring.Net
- StructureMap
- Unity


The code in this branch will first check that the object is registered 
with the container before requesting it, e.g.:

    if (k.IsRegistered<IDummy>())
       (k.Resolve<IDummy>()).Do();

As the test on [my blog](http://philipm.at/2011/0808/) show, most containers 
behave pretty decent, except for **Unity** whose `IsRegistered` method 
has abysmal performance when the container contains a large numbers of 
objects registered.

You might also be interested in the *without_isregistered* branch (guess
what it does), and if you're interested in **Unity** the *ex_vs_isreg_vs_opt*
has the recommended approach in dealing with optional class registration 
in **Unity**, the `OptionalDependencyAttribute`.

