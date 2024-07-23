# Log Sequence Merge (LSM) Demo

This project demonstrates Log Sequence Merge (LSM) and Sorted String Tables (SST).  The application creates data files.  Indexes the files.  Searches for keys and values in the files.  Merges two sorted files.
This is similiar to Compaction, but duplicates are not removed.

## Description

  A console-mode demonstration of LSM and SST.  The demonstration is divided into six sections, marked Demo1-6.  The demonstrations can be run individually or in groups.

## Install and Build

The is a C# Console-Mode Project.  Open with  Visual Studio 2022 and above to compile. 

## Sample File

A sample file is attached which shows the output of the program.

## References

   1. "SSTables and LSM Trees", Rahul Pradeep, June 2021, Medium.com, https://rahulpradeep.medium.com/sstables-and-lsm-trees-5ba6c5529325

   2. "LSM Trees: The Go-To Data Structure for Database, Search Engines and More", Ankit Dwivedi, May 2023, Medium.com

   3. "A Survey of LSM-Tree based Indexes, Data Systems and KV-Stores", Supriya Mishra, Feb 2024, Arxiv.org, https://arxiv.org/html/2402.10460v2

