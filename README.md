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

This repository contains various branches dedicated to multiple DI usage 
scenarios in an attempt to provide a comprehensive landscape for 
measurements. Don't rely on the *master* branch maintaining a specific 
topic, it might change its content. Instead look at those branches for the 
specific scenarios that might be of interest to you.
The only thing I can somewhat promise is that the master branch will have
the most up-to-date spreadsheet with my results.

- *with_isregistered*: checks that the object is registered with the container 
before requesting it. This causes some abysmal performance in **Unity**.
- *without_isregistered*: requests the object without performing the 
registration check. Has the potential to yield either `NullReferenceException`s 
or container specific registration exceptions.
- *ex_vs_isreg*: compares the speed difference between using `IsRegistered` 
and handling specific registration exceptions. Spoiler: don't use exceptions.
- *ex_vs_isreg_vs_opt*: **Unity** provides an alternate way to deal with 
objects not being registered, `OptionalDependencyAttribute`. This branch,
a bit badly named, attempt to look at how this attribute performs.


