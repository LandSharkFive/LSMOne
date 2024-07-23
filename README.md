# Log Structured Merge Tree (LSM) Demo

This project demonstrates Log Structured Merge Tree (LSM) and Sorted String Tables (SST).  Creates data files.  Indexes.  Search for keys and values.  Merges two sorted files.  Merging is similiar to Compaction, but duplicates are allowed.  The records would be sorted by key and timestamp in a production system.

## Description

  A console-mode demonstration of LSM and SST.  The are six demonstrations, marked Demo1-6. 

## Install and Build

The is a C# Console-Mode Project.  Open with  Visual Studio 2022 and above to compile. 

## Sample File

A sample file shows the output of the program.

## References

   1. "SSTables and LSM Trees", Rahul Pradeep, June 2021, Medium.com, https://rahulpradeep.medium.com/sstables-and-lsm-trees-5ba6c5529325

   2. "LSM Trees: The Go-To Data Structure for Database, Search Engines and More", Ankit Dwivedi, May 2023, Medium.com

   3. "A Survey of LSM-Tree based Indexes, Data Systems and KV-Stores", Supriya Mishra, Feb 2024, Arxiv.org, https://arxiv.org/html/2402.10460v2

