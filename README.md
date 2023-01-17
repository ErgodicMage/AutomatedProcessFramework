# Automated Process Framework
A framework for developing automated processes.

## Not your father's batch program
Often an automated process is confused with older style batch programs that used to run through Windows Task Scheduler or Unix Cron Jobs; actually this is still done often. They would start a program that would do some work (usually very specific) and then quit running until the next time.

An automated process takes this simple idea of batch process and puts in on steroids to cover a much larger set of requirements for the work being done and how/when that work is done. The Automated Process Framework (APF) is a set tools, components and utilities to help in writing automed processes with complex requirements for both work and kicking off.

Note: I probably shouldn't say "father's" batch program because I've been doing this for 20+ years and am soon to be a grandfather; so maybe call it "Not your grandfather's batch program" :laughing:.

## What is Automated
The Cambridge Dictionary gives a very good definition of [automated](https://dictionary.cambridge.org/us/dictionary/english/automated) "carried out by machines or computers without needing human control". Of course in the context of APF it is computers not servers doing the work, sometimes on laptops/desktops but more often on servers.

For example, I place an order with Amazon for a new mouse for my laptop. Once I place the order I do not have to do anything at all to receive the new mouse. Amazon checks my payment options and uses the correct one if there's funds, checks inventory warehouses and suppliers, ships it to the warehouse near me and then a driver delivers to my door, my German Shephard to bark warningingly (yeah he does) which tells me my package has arrived. (Note: we have Alex which also notifies us when a package arrives, but Shadow is much more ummm enthusiastic about it). I click and everything else is automted (including Shadow lol), all I have to do us open the door and bring in the package. The work I do to get the new mouse is small beacuse everything else is automed.


In the APF the automated work is considered to be an application (or set of applications) which run continuously and processes work when it should do so. APF does not provide the program (except for examples) but does provide much of what is needed besides the actual code to do the work.

