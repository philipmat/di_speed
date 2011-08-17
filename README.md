# Test of speed of DI Containers

This branch contains code to test Unity's `OptionalDependencyAttribute`.
It doesn't contain all the tests from other branches, and it also runs 
the tests a bit different: instead of loading the containers with 222 
interfaces from the beginning, it starts with 1 and it progressively ramps 
up the numbers of interfaces registered in increments of 20 (or 50 
if you run from Visual Studio) up to 222, rebuilding the containers 
on each of these increments (the container rebuild/teardown are not 
part of the performance measurements).

If you want to run it, you'll need to compile two separate targets:

- compile Release (or Debug) if you want to the `singleton_loaded` tests
- compile Release-Opt (or Debug-Opt) if you want to run the 
`singleton_loaded_opt_0`, meaning it runs with optional dependencies on 
`SimpleDummies` but there are no dependencies registered to satisfy them, 
or `singleton_loaded_opt_1`, meaning there is now one dependencies 
registered to satisfy them.

Since from previous runs the singleton and transient cases seemed to 
have some correlation, I only coded the singleton case.
