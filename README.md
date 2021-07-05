# CCSDS in Forth

This repository contains a basic implementation of the CCSDS Space Packet
Protocol Primary Header. This is a simple packet header with basic information,
and the code simply provides access to the fields according to the standard.


I like to see how this header looks in different programming languages, so this
is my writeup of the primary header in Forth. This is a test of the language's
ability to deal with binary data, to handle endianness, and to manipulate bit
field definitions, which are common concerns for embedded systems programmers.


## Notes

This implementation is extremely basic. It uses bit shifts and masks to get and
set each field within the header. This is what I am actually interested in
doing with a CCSDS header, so this code gets right to the point.


It is interesting to note that there is no structure definitions anywhere- you
could very well define structures, and then accessors for the bits in their
fields. This would make some of the definitions slightly simpler, but I don't
think it would be by very much.


The nice thing about Forth is that I don't feel as pressured to wrap things up
as nicely- there are other options for this kind of library which create
abstractions or use generic bit field manipulation words to extract or lay down
sections of bits, but I don't feel like it would be Forthy to do this. 


Compared to other implementations, such as my Zig and Rust ones, my Forth code
is smaller, denser, and with much more code per line. I like the Zig version
the best, but the Forth does have a certain charm.


## Conventions

I used a convention where a ">" prefix indicates that a value is being
loaded to somewhere, in this case a field within the header, whlie a suffix
of ">" indicates that a value is loaded from somewhere.

This leads to definitions such as "\>apid" or "length>", which are possible
because of Forth's unrestricted identifier names.

You would use these as in the following code which allocates a header and sets
the APID and sequence flag, resulting in a valid packet with 1 data byte:

```forth
1 constant APID
3 constant UNSEGMENTED
PRILENGTH 1+ allot constant packet
packet PRILENGTH 1+ erase
APID packet >apid
UNSEGMENTED packet >seqflag
```


## Utility Definitions

There are a handleful of utilities defined in ccsds.fs. Forth is a very
free-form language, so it is both easy and natural to extend it to match your
problem.


In this case I added a few definitions to increment characters while stepping
through memory  with c@++ and c!++, load and store words (16 bit integers) with
w! and w@, and to turn a word count into a byte count like words.


The last utility is 'masked'. This is a somewhat complex word which takes a
mask, a value and a new value, and ORs the two values in after clearing the
bits in the given mask. The definition of 'masked' is particularly neat in my
opinion: "invert and or" is the C equivalent of "a | (b & ~c)"


## Tests

I liked being able to sprinkle asserts into the code, as with Zig and Rust,
although in this case I'm not using any kind of test framework, not even a
build in one, just asserts as test cases. This nice thing here is that unless
you ask for them to be turned off, you must pass the test suite in order to
even use the code.

I moved the tests to a separate file to make the SLOC count easier (27 lines),
but there is no real reason to extract these- the code can just test itself
every time it is loaded- Forth compiles very quickly.

