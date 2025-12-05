# iceoryx2-csharp

C# / .NET bindings for iceoryx2 - Zero-Copy Lock-Free IPC

> [!IMPORTANT]
> This repository is meant to be integrated into eclipse-iceoryx soon.

## 🎯 Status

**✅ Production-Ready C# Bindings!**

* ✅ Cross-platform library loading (macOS tested, Linux/Windows ready)
* ✅ Complete P/Invoke FFI layer for all core APIs
* ✅ Memory-safe resource management with SafeHandle pattern
* ✅ High-level C# wrappers with builder pattern
* ✅ **Publish-Subscribe API** - Full implementation with type safety and zero-copy
* ✅ **Event API** - Complete notifier/listener implementation with
  blocking/timed waits
* ✅ **Request-Response API** - Complete client/server RPC with verified FFI signatures
* ✅ **Complex Data Types** - Full support for custom structs with sequential layout
* ✅ **Async/Await Support** - Modern async methods for all blocking operations
  with CancellationToken
* ✅ **CI/CD** - GitHub Actions workflow for multi-platform builds and NuGet packaging
* ✅ Tests passing on macOS
* ✅ Working examples for all major APIs (Pub/Sub, Event, RPC)
* ✅ Production-ready with proper memory management and error handling
* ⚠️ Requires native library: `libiceoryx2_ffi_c.{so|dylib|dll}`
  (included in git submodule)

## Overview

This package provides C# and .NET bindings for iceoryx2, enabling
zero-copy inter-process communication in .NET applications.
The bindings use P/Invoke to call into the iceoryx2 C FFI layer
and provide idiomatic C# APIs with full memory safety.

### Key Features

* 🚀 **Zero-copy IPC** - Share memory between processes without serialization
* 🔒 **Type-safe** - Full C# type system support with compile-time checks
* 🧹 **Memory-safe** - Automatic resource management via SafeHandle and IDisposable
* 🎯 **Idiomatic C#** - Builder pattern, Result types, LINQ-friendly APIs
* 🔧 **Cross-platform** - Works on Linux, macOS, and Windows
* 📦 **Multiple patterns** - Publish-Subscribe, Event, and Request-Response communication
* ⚡ **Async/Await** - Full async support with CancellationToken for modern C# applications

## Quick Start

### Option 1: Install from NuGet (Recommended)

```bash
dotnet add package Iceoryx2
```

Or add to your `.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="Iceoryx2" Version="0.1.0" />
</ItemGroup>
```

The NuGet package includes pre-built native libraries for macOS, Linux, and Windows.

### Option 2: Build from Source

> [!IMPORTANT]
> **iceoryx2** is included as a **git submodule** and must be
> initialized and
> built **before** building the .NET project.

#### 1. Clone with Submodules

```bash
# Clone the repository with submodules
git clone --recursive https://github.com/eclipse-iceoryx/iceoryx2-csharp.git
cd iceoryx2-csharp

# Or if already cloned, initialize submodules
git submodule update --init --recursive
```

#### 2. Build the Native Library (iceoryx2)

The iceoryx2 C FFI library **must be built first** as the .NET project
depends on it:

```bash
# From repository root
cd iceoryx2
cargo build --release --package iceoryx2-ffi-c
cd ..
```

This creates the native library at:

* Linux: `iceoryx2/target/release/libiceoryx2_ffi_c.so`
* macOS: `iceoryx2/target/release/libiceoryx2_ffi_c.dylib`
* Windows: `iceoryx2/target/release/iceoryx2_ffi_c.dll`

#### 3. Build the C# Bindings

```bash
# From repository root
dotnet build
```

The build automatically copies the native library from `iceoryx2/target/release/`
to the output directories.

#### 4. Run Tests

```bash
dotnet test
```

### 3. Run the Publish-Subscribe Example

```bash
# Terminal 1 - Publisher
cd examples/PublishSubscribe
dotnet run -- publisher

# Terminal 2 - Subscriber
cd examples/PublishSubscribe
dotnet run -- subscriber
```

You should see the subscriber receiving incrementing counter values from the publisher!

## Prerequisites

* **.NET 8.0 or .NET 9.0 SDK** ([Download](https://dotnet.microsoft.com/download))
* **Rust toolchain** (for building the iceoryx2 C FFI library) - Install via [rustup](https://rustup.rs/)
* **C compiler and libclang** (required for building iceoryx2):
    * **Linux**: `sudo apt-get install clang libclang-dev`
    * **macOS**: `brew install llvm` (usually pre-installed with Xcode)
    * **Windows**: MSVC Build Tools (usually included with Visual Studio)

> [!NOTE]
> The iceoryx2 project is included as a **git submodule**. You must initialize
> it before building.

## Build Instructions

### 1. Initialize Git Submodules

```bash
# If you haven't cloned with --recursive
git submodule update --init --recursive
```

### 2. Build the iceoryx2 Native Library

> [!IMPORTANT]
> The iceoryx2 C FFI library **must be built before** the .NET project.

```bash
# From repository root
cd iceoryx2
cargo build --release --package iceoryx2-ffi-c
cd ..
```

This creates the native library in `iceoryx2/target/release/`:

* Linux: `libiceoryx2_ffi_c.so`
* macOS: `libiceoryx2_ffi_c.dylib`
* Windows: `iceoryx2_ffi_c.dll`

### 3. Build the .NET Project

```bash
# From repository root
dotnet build --configuration Release
```

The build process automatically:

* Copies the native library to all output directories
* Builds all projects (iceoryx2, iceoryx2.Reactive, tests, examples)

### 4. Run Tests

```bash
dotnet test --configuration Release
```

### 5. Build Examples

All examples are built automatically with the solution. To run a specific example:

**Publish-Subscribe Example:**

```bash
# Terminal 1 - Run publisher
cd examples/PublishSubscribe
dotnet run -- publisher

# Terminal 2 - Run subscriber
cd examples/PublishSubscribe
dotnet run -- subscriber
```

**Event Example:**

```bash
# Terminal 1 - Run notifier
cd examples/Event
dotnet run -- notifier

# Terminal 2 - Run listener
cd examples/Event
dotnet run -- listener
```

### Alternative: Use the Build Script

A convenience build script is provided that handles all steps:

```bash
./build.sh
```

This script:

1. Builds the iceoryx2 C FFI library
2. Generates C# bindings (optional)
3. Builds the .NET solution
4. Runs tests
5. Builds examples

### Platform-Specific Native Library Names

The C# bindings automatically detect and load the correct native library for
your platform:

| Platform    | Library Names (tried in order)                    |
| ----------- | ------------------------------------------------- |
| **Linux**   | `libiceoryx2_ffi_c.so`, `iceoryx2_ffi_c.so`       |
| **macOS**   | `libiceoryx2_ffi_c.dylib`, `iceoryx2_ffi_c.dylib` |
| **Windows** | `iceoryx2_ffi_c.dll`, `libiceoryx2_ffi_c.dll`     |

## Project Structure

```text
iceoryx2-csharp/
├── iceoryx2/                            # Git submodule - iceoryx2 Rust implementation
├── src/
│   ├── Iceoryx2/                        # Main C# library
│   │   ├── Native/                      # C-bindings via P/Invoke
│   │   ├── SafeHandles/                 # Memory-safe resource management
│   │   ├── Core/                        # High-level API wrappers
│   │   ├── PublishSubscribe/            # Pub/Sub messaging pattern
│   │   ├── Event/                       # Event-based communication
│   │   ├── RequestResponse/             # Request-Response (RPC) pattern
│   │   └── Types/                       # Common types and utilities
│   └── Iceoryx2.Reactive/              # Reactive Extensions support
├── examples/                            # C# examples
│   ├── PublishSubscribe/               # Pub/Sub example
│   ├── ComplexDataTypes/               # Complex struct example
│   ├── Event/                          # Event API example
│   ├── RequestResponse/                # Request-Response RPC example
│   └── AsyncPubSub/                    # Async/await patterns example
├── tests/                              # Unit tests
└── README.md
```

## Usage Examples

Detailed usage examples for different patterns (Publish-Subscribe, Event,
Request-Response, etc.) can be found in [examples/README.md](examples/README.md).

> [!NOTE]
> To run the examples, you must specify the target framework:
> `dotnet run --framework net9.0`

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct,
and the process for submitting pull requests to us.

## Roadmap

See [ROADMAP.md](ROADMAP.md) for the current project roadmap and future plans.

## License

Licensed under either of

* Apache License, Version 2.0 ([LICENSE-APACHE](./LICENSE-APACHE) or <https://www.apache.org/licenses/LICENSE-2.0>)
* MIT license ([LICENSE-MIT](./LICENSE-MIT) or <https://opensource.org/licenses/MIT>)

at your option.

### Contribution

Unless you explicitly state otherwise, any contribution intentionally submitted
for inclusion in the work by you, as defined in the Apache-2.0 license, shall be
dual licensed as above, without any additional terms or conditions.
