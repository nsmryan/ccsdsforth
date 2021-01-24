# CCSDS in Forth
This repository contains a basic implementation of the CCSDS Space Packet Protocol
Primary Header. This is a simple packet header with basic information.


I like to see how this header looks in different programming languages, so
this is my writeup of the primary header in Forth.


## Notes
This implementation is extremely basic. It simply uses bit shifts and masks to
get and set each field within the header.


There is no way, for example, to get a sequence flag out of a single word- it
must be used within a primary header. This keeps the code simple and uniform,
although perhaps more intricate then necessary and with no way to visualize
the entire header structure as with a struct/bitfield style definition.


The nice thing about Forth is that I don't feel as pressured to wrap things
up as nicely- there are other options for this kind of library which
create abstractions or use generic bit field manipulation words to extract
or lay down sections of bits, but I don't feel like it would be Forthy
to do this. 


Compared to other implementations, such as my Zig and Rust ones, my
Forth code is smaller, denser, and with much more code per line.

I liked being able to sprinkle asserts into the code, as with Zig
and Rust, although in this case I'm not using any kind of test framework,
not even a build in one, just asserts as test cases. This nice
thing here is that unless you ask for them to be turned off,
you must pass the test suite in order to even use the code.


In a very unscientific series of tests, I found that this code took about
2.5 ms to compile on my laptop. 
