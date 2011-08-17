# Test of speed of DI Containers

Attempting to test the speed of various Dependency Injection Containers.

.Net Containers used in testing:

- Autofac
- Castle.Windsor
- ninject 
- Spring.Net
- StructureMap
- Unity

The *with_isregistered* branch checks to see that an object is registered 
with the container before requesting it, e.g.:
    
    if (k.IsRegistered<IDummy>())
        (k.Resolve<IDummy>()).Do();

This branch, *without_isregistered* does not perform that registration.
For most container the cost is minimal, but some people believe somewhere 
between "not a common scenario" to "`IsRegistered` is an anti-pattern", so
I chose to also write the tests without registration checking.

I believe this is a case that is closer to a full DI buy-in, whereas the 
`IsRegistered` case would be more common with a *Service Locator* type 
of (anti-) pattern.
