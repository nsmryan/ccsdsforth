6 constant PRILENGTH
0x07FF constant APIDMASK
0xE000 constant VERSIONMASK
0x1000 constant PACKETTYPEMASK
0x0800 constant SECHEADERMASK

0xC000 constant SEQFLAGMASK 
0x3FFF constant SEQUENCEMASK 

: c@++  dup c@ swap 1+ ;
assert( 0xFF here c! here c@++ here 1+ = swap 0xFF = and )

: c!++  tuck c! 1+ ;
assert( 0x00 here c!  0xFF here c!++ here - 1 = here c@ 0xFF = and )

: w@ c@++ c@ swap 8 lshift or ;
assert( 1 here c! 2 here 1+ c! here w@ 0x0102 = )

: w! over 0xFF00 and 8 rshift swap c!++ swap 0xFF and swap c! ;
assert( 0x0304 here w! here c@ 3 = here 1 + c@ 4 = and )

: words 2 * ;

: apid>          w@ APIDMASK and ;
: version>       w@ VERSIONMASK and 13 rshift ;
: packettype>    w@ PACKETTYPEMASK and 12 rshift ;
: secheaderflag> w@ SECHEADERMASK and 11 rshift ;

: seqflag>       1 words + w@ SEQFLAGMASK and 14 rshift ;
: sequence>      1 words + w@ SEQUENCEMASK and ;

: length>        2 words + w@ ;


: >apid          swap over w@ APIDMASK invert and or swap w! ;
: >version       swap 13 lshift over w@ VERSIONMASK invert and or swap w! ;
: >packettype    swap 12 lshift over w@ PACKETTYPEMASK invert and or swap w! ;
: >secheaderflag swap 11 lshift over w@ SECHEADERMASK invert and or swap w! ;

: >seqflag       1 words + swap 14 lshift over w@ SEQFLAGMASK invert and or swap w! ;
: >sequence      1 words + swap over w@ SEQUENCEMASK invert and or swap w! ;

: >length        2 words + w! ;

assert( here PRILENGTH erase 0x07FF here >apid here apid> 0x07FF = )
assert( here PRILENGTH erase 0x0007 here >version here version> 0x0007 = )
assert( here PRILENGTH erase 0x0001 here >packettype here packettype> 0x0001 = )
assert( here PRILENGTH erase 0x0001 here >secheaderflag here secheaderflag> 0x0001 = )

assert( here PRILENGTH erase 0x0003 here >seqflag here seqflag> 0x0003 = )
assert( here PRILENGTH erase 0x3FFF here >sequence here sequence> 0x3FFF = )

assert( here PRILENGTH erase 0xFFFF here >length here length> 0xFFFF = )
