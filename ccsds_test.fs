include ccsds.fs

assert( 0xFF here c! here c@++ here 1+ = swap 0xFF = and )
assert( 0x00 here c!  0xFF here c!++ here - 1 = here c@ 0xFF = and )

assert( 1 here c! 2 here 1+ c! here w@ 0x0102 = )
assert( 0x0304 here w! here c@ 3 = here 1 + c@ 4 = and )


assert( here PRILENGTH erase 0x07FF here >apid here apid> 0x07FF = )
assert( here PRILENGTH erase 0x0007 here >version here version> 0x0007 = )
assert( here PRILENGTH erase 0x0001 here >packettype here packettype> 0x0001 = )
assert( here PRILENGTH erase 0x0001 here >secheaderflag here secheaderflag> 0x0001 = )

assert( here PRILENGTH erase 0x0003 here >seqflag here seqflag> 0x0003 = )
assert( here PRILENGTH erase 0x3FFF here >sequence here sequence> 0x3FFF = )

assert( here PRILENGTH erase 0xFFFF here >length here length> 0xFFFF = )
