6 constant PRILENGTH
0x07FF constant APIDMASK
0xE000 constant VERSIONMASK
0x1000 constant PACKETTYPEMASK
0x0800 constant SECHEADERMASK

0xC000 constant SEQFLAGMASK 
0x3FFF constant SEQUENCEMASK 

: c@++  dup c@ swap 1+ ;

: c!++  tuck c! 1+ ;

: w@ c@++ c@ swap 8 lshift or ;

: w! over 0xFF00 and 8 rshift swap c!++ swap 0xFF and swap c! ;

: words 2 * ;

: apid>          w@ APIDMASK and ;
: version>       w@ VERSIONMASK and 13 rshift ;
: packettype>    w@ PACKETTYPEMASK and 12 rshift ;
: secheaderflag> w@ SECHEADERMASK and 11 rshift ;

: seqflag>       1 words + w@ SEQFLAGMASK and 14 rshift ;
: sequence>      1 words + w@ SEQUENCEMASK and ;

: length>        2 words + w@ ;

: masked         ( n n' mask -- n | (n' & ~mask ) invert and or ;
: >apid          tuck w@ APIDMASK masked swap w! ;
: >version       swap 13 lshift over w@ VERSIONMASK masked swap w! ;
: >packettype    swap 12 lshift over w@ PACKETTYPEMASK masked swap w! ;
: >secheaderflag swap 11 lshift over w@ SECHEADERMASK masked swap w! ;

: >seqflag       1 words + swap 14 lshift over w@ SEQFLAGMASK masked swap w! ;
: >sequence      1 words + swap over w@ SEQUENCEMASK masked swap w! ;

: >length        2 words + w! ;

