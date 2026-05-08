# LSMOne

An experimental C# implementation of a Log-Structured Merge-Tree (LSM). This project represents a first-pass architectural study into high-velocity write performance and immutable storage layers.

### Context: The First Attempt
This is an initial exploratory project. It was built to map out the complexities of sequential I/O and the MemTable-to-SSTable pipeline. While the core write path is functional, it is intentionally kept lean to focus on structural mechanics rather than production-grade complexity.

### The Architecture
* **MemTable:** In-memory buffer for immediate, low-latency writes.
* **SSTables:** Immutable, sorted string tables persisted to disk.
* **Indexing:** Sparse indexing for efficient range queries.

### Current Status: The Merge Challenge
The complexity of the N-way merge (Compaction) is the primary hurdle in this implementation.
* **Write Path:** Fully operational.
* **Read Path:** Implemented via multi-level search.
* **Compaction:** Currently a work-in-progress. Merging levels while minimizing write amplification is the next phase of the evolution.

### Performance Philosophy
LSMOne treats data as a stream of immutable events. By avoiding "update-in-place" operations, the system minimizes random disk seeks—a fundamental requirement for modern, write-heavy distributed systems.

---

### Build & Run
* **Environment:** .NET 6.0+ / C#
* **Note:** This is an educational POC. If you are an LSM expert, you will notice the merge step is still being tamed.

### References
* **Bigtable:** A Distributed Storage System for Structured Data (Chang et al.)
* **The Log-Structured Merge-Tree (LSM-Tree)** (Patrick O'Neil et al.)
