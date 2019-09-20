# Negzero

[![Build Status](https://travis-ci.org/valantonini/Negzero.svg?branch=master)](https://travis-ci.org/valantonini/Negzero)


A second attempt at a performant 2d dungeon generator.

Currently implement an [A* algorithm and Fibonacci heap](https://github.com/valantonini/PerfectPath) for world traversal.

For bitmap rendering on OSX
```bash
brew install mono-libgdiplus
```

For bitmap rendering on Linux, maybe (untested):
```bash
sudo apt install libc6-dev 
sudo apt install libgdiplus
```