# Contributing to BankPOS

First off — thanks for considering a contribution. This is a small, learning-friendly project, so contributions of any size are welcome: a typo fix, a new endpoint, a bug report, or a question that helps us write better docs all count.

This guide borrows its structure from the contributing guides of larger projects (like [Flutter's](https://github.com/flutter/flutter/blob/master/CONTRIBUTING.md)), scaled down to fit a project this size. You don't need to read all of it before opening your first PR — skim the sections that are relevant to what you're doing.

## Code of Conduct

Be respectful, be patient, and assume good intent. Disagreements about code are fine and expected; disrespect isn't. If a conversation turns unproductive, step back before responding. We want this to be a welcoming place for people who are still learning ASP.NET Core, not just for experienced .NET developers.

## Ways to contribute

You don't have to write code to contribute:

- **Report a bug** — open an issue with steps to reproduce, what you expected, and what actually happened.
- **Suggest an improvement** — open an issue describing the problem first, before writing the code. This avoids duplicate work and lets us discuss the approach.
- **Improve the docs** — fix a typo, clarify a confusing paragraph, add a missing example. These PRs are reviewed quickly.
- **Write code** — fix a bug, implement an endpoint, add tests. See [Finding something to work on](#finding-something-to-work-on) below.

If you're unsure whether something is worth doing, open an issue and ask before you spend time on it.

## Before you start

1. Fork the repo and clone your fork:
   ```bash
   git clone https://github.com/<your-username>/BankPOS.git
   cd BankPOS
   ```
2. Add the original repo as an upstream remote, so you can keep your fork in sync:
   ```bash
   git remote add upstream https://github.com/<original-org>/BankPOS.git
   ```
3. Make sure it builds before you change anything:
   ```bash
   dotnet restore
   dotnet build
   ```
4. Create a branch off `main` for your change — don't work directly on `main`:
   ```bash
   git checkout -b fix/short-description
   ```

## Finding something to work on

If you're new to the codebase, these are good starting points — they're self-contained and don't require deep knowledge of the whole system:

- **`good first issue`** — small, well-scoped tasks. Start here if this is your first PR to the project.
- **`help wanted`** — larger tasks we'd genuinely like help with.

A few concrete examples pulled straight from the current codebase, if no issues are filed yet:

- Route naming is inconsistent (`/api/GetTransactions` vs `/api/createAccount`) — picking a convention (e.g. lowercase kebab-case, or standard REST verbs/nouns) and applying it consistently across controllers is a great first PR.
- `GetCustomerAccountsResponse` exists in `AccountDto.cs` but has no controller action returning it yet — wiring up a `GET /api/accounts/{customerId}` endpoint would close that gap.
- `Till` and `ShiftSession` entities exist but have no controllers or services at all — a good intermediate-sized contribution.
- No validation errors are currently returned (everything returns `Ok`, even on missing/invalid data) — adding proper `400`/`404` responses with `ProblemDetails` would meaningfully improve the API.

If you want to work on something not listed here, open an issue first to check it's a good fit before you invest time in it.

## Style guide

Nothing exotic — just standard, idiomatic C#:

- Follow the [.NET / C# coding conventions](https://learn.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions).
- `PascalCase` for classes, methods, and public properties. `camelCase` for local variables and parameters.
- Keep controllers thin — request handling and status codes only. Business logic belongs in the service layer (`ITransactionService`, `IAccountService`, etc.), not the controller.
- DTOs (in `BankPOS.DTOs`) are what cross the wire. Entities (in `BankPOS.Entities`) are what gets persisted. Don't return entities directly from a controller — map to a DTO first.
- Run `dotnet format` before committing, so we're not reviewing whitespace diffs.

## Commit messages

Write commit messages that explain _why_, not just _what_:

```
Add validation for negative transaction amounts

CreateTransaction previously accepted negative amounts for deposits,
which silently corrupted account balances. This adds a check in
TransactionService and returns a 400 with a clear error message.
```

Small, focused commits are easier to review than one giant commit that touches ten files.

## Testing

If the change you're making affects behavior (not just docs or formatting), please add or update a test alongside it. There isn't a full test suite in place yet — if you're adding the first tests for a given service or controller, that's a very welcome contribution on its own.

Run tests with:

```bash
dotnet test
```

## Submitting a pull request

1. Push your branch and open a PR against `main`.
2. Fill in the PR description: what changed, why, and how you tested it. A short description saves the reviewer a lot of guesswork.
3. Link the issue your PR addresses, if there is one (`Closes #12`).
4. Keep the PR focused. If you find an unrelated bug while working, file a separate issue/PR for it rather than bundling it in.
5. Be responsive to review comments — most PRs need at least one round of feedback, and that's normal, not a sign something went wrong.

## Review process

Since this is a small project, review turnaround depends on maintainer availability — please be patient. A PR is generally merged once:

- It builds and passes existing tests.
- The change is scoped to what the issue/PR description says it does.
- Reviewer feedback (if any) has been addressed.

## Questions

If anything in this guide is unclear, that's a bug in the guide — please open an issue about it. Documentation confusion is exactly the kind of thing this project wants to fix quickly.

Thanks again for contributing.
