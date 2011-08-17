# Test of speed of DI Containers

The purpose of this branch is to compare the `IsRegistered` method 
vs. handling registration exceptions if you attempt to request and object
that is not registered with the container.

The code in this branch only compares the *singleton loaded* scenario, and 
furthermore in only focused on **Unity** with **Autofac** thrown in
for a baseline comparison.

Unlike the master and the *without_isregistered* branches, these *singleton 
loaded* scenarios don't start with the containers fully loaded with the 
222 interfaces, but instead start with 1 and ramp up, in increments of 20 
(or 50 if you start from Visual Studio), to 221.

Word to the wise: don't run more than 10k with exceptions for **Unity**.
As of my last test, a 10k run with 221 interfaces takes about 4 minutes. 
The whole test will take about 45 minutes to complete. If you run a 5x10k, 
be prepared for several hours of waiting.

You might also be interested in the *ex_vs_isreg_vs_opt* branch, which 
shows a better way to use **Unity** when you need to deal with classes 
that might not be registered in the container.

