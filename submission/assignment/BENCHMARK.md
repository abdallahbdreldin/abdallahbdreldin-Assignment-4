
### Benchmark Results

| Method                     | Iterations |               Mean |        Allocated |
| -------------------------- | ---------: | -----------------: | ---------------: |
| StringConcatenation        |        100 |         2,076.3 ns |         20.37 KB |
| StringBuilderConcatenation |        100 |       **573.1 ns** |      **1.25 KB** |
| StringConcatenation        |      1,000 |         197,187 ns |      2,773.88 KB |
| StringBuilderConcatenation |      1,000 |     **5,664.8 ns** |     **14.37 KB** |
| StringConcatenation        |     10,000 |      30,835,101 ns |    370,543.41 KB |
| StringBuilderConcatenation |     10,000 |    **66,378.2 ns** |    **155.69 KB** |
| StringConcatenation        |    100,000 |   7,411,186,642 ns | 46,792,138.23 KB |
| StringBuilderConcatenation |    100,000 | **1,690,883.5 ns** |  **1,931.09 KB** |

### Answers

**1. Which approach was faster with 100 iterations?**

`StringBuilderConcatenation` was faster.

* String concatenation: **2,076.3 ns**
* StringBuilder: **573.1 ns**

---

**2. Which approach was faster with 100,000 iterations?**

`StringBuilderConcatenation` was faster.

* String concatenation: **7,411,186,642.3 ns**
* StringBuilder: **1,690,883.5 ns**

The difference becomes extremely large as the number of iterations increases.

---

**3. Which approach allocated more memory?**

`StringConcatenation` allocated significantly more memory at every tested iteration count.

For example, at 100,000 iterations:

* String concatenation: **46,792,138.23 KB**
* StringBuilder: **1,931.09 KB**

---

**4. What happened to string concatenation performance as the loop size increased?**

Its performance became dramatically worse as the number of iterations increased.

The mean increased from:

```text
100 iterations       → 2,076.3 ns
1,000 iterations     → 197,187 ns
10,000 iterations    → 30,835,101 ns
100,000 iterations   → 7,411,186,642 ns
```

In comparison, `StringBuilder` increased much more gradually.

---

**5. Why does repeated string concatenation create additional allocations?**

Strings in C# are **immutable**. This means that when we do:

```csharp
result += i;
```

the existing string cannot be modified. A new string must be created containing the previous content plus the new value.

Repeated concatenation therefore creates many temporary string objects and causes more memory allocations.

---

**6. Why does StringBuilder usually perform better when text is repeatedly appended?**

`StringBuilder` is designed for modifying text repeatedly. It uses an internal buffer that can be expanded when necessary.

Instead of creating a completely new string for every append, it can reuse its internal storage:

```csharp
builder.Append(i);
```

This reduces the number of allocations and the amount of copying required, which is reflected in your benchmark results.

---

**7. Is StringBuilder always better than normal string operations? Explain.**

No.

`StringBuilder` is particularly useful when **many strings are repeatedly appended**, especially inside large loops.

For a small number of simple concatenations, using normal string operations can be simpler and may not have a meaningful performance disadvantage.

In this benchmark, however, the difference became very significant as the iteration count increased.
