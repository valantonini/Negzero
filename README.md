# Negzero

[![Build Status](https://travis-ci.org/valantonini/Negzero.svg?branch=master)](https://travis-ci.org/valantonini/Negzero)


A second attempt at a performant 2d dungeon generator.


A Fibonacci Heap to outperform a priority queue with

Heap: 181262 processed in 87ms
Queue: 181262 processed in 22ms

variance 65ms (300%) ❌

For bitmap rendering on OSX
```bash
brew install mono-libgdiplus
```

For bitmap rendering on Linux, maybe (untested):
```bash
sudo apt install libc6-dev 
sudo apt install libgdiplus
```