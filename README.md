# Log Structured Merge Tree (LSM) Demo

This project demonstrates a Log Structured Merge Tree (LSM) and Sorted String Tables (SST).  Create and index data files.  Search for keys and values.  Merge two sorted files.  Merging is like Compaction.  In production systems, the records are sorted by key and timestamp.

## Description

A console-mode demonstration of LSM and SST.  

## Install and Build

The is a C# Console-Mode Project.  Open with  Visual Studio 2022 and above to compile. 

## Sample File

A sample file shows the output of the program.

## Which databases use LSM?

Cassandra, DynamoDB, HBase, MongoDB, RocksDB and Schylla.

## References

   1. "SSTables and LSM Trees", Rahul Pradeep, June 2021, Medium.com, https://rahulpradeep.medium.com/sstables-and-lsm-trees-5ba6c5529325

   2. "LSM Trees: The Go-To Data Structure for Database, Search Engines and More", Ankit Dwivedi, May 2023, Medium.com

   3. "A Survey of LSM-Tree based Indexes, Data Systems and KV-Stores", Supriya Mishra, Feb 2024, Arxiv.org, https://arxiv.org/html/2402.10460v2

