# grade_analyzer.py
# Drop the lowest score per student, compute finals/median/top-N,
# per-assignment averages, improvement jumps, and pass rate.

STUDENTS = [
    {"name": "Alice",  "scores": [70, 82, 90, 88]},
    {"name": "Bob",    "scores": [60, 59, 61, 62]},
    {"name": "Carlos", "scores": [95, 90, 92, 96]},
    {"name": "Dana",   "scores": [80, 84, 79, 85]},
]

ranked_names = []

def final_grade(scores):
    ###This was initially modifying the original scores list so it would end up returning a division by zero error. Copied scores list to local variable "x" instead so as to preserve original scores list. It was also dropping the largest number with max(scores) instead of min(scores).
    if not scores:
        return 0.0
    x = scores.copy()
    drop = min(x)
    x.remove(drop)
    return sum(x) / len(x)

def class_median(students):
    """Median of students' final grades.""" ###now solves for the median if the amount of students is even, nothing changes for an odd amount of students
    finals = sorted(final_grade(s["scores"]) for s in students)
    n = len(finals)
    mid = n // 2
    if len(finals) % 2 == 0:
        return (finals[mid] + finals[mid-1]) / 2
    else:
        return finals[mid]

def largest_single_jump(scores):
    """
    Biggest positive improvement between consecutive assignments (next - current).
    e.g., [70, 82, 90, 88] -> max jump is +12.
    """
    if len(scores) < 2:
        return 0
    best = float("-inf")
    for i in range(len(scores) - 1):
        jump = scores[i+1] - scores[i] ###Changed from "scores[i] - scores[i+1]" to "scores[i+1] - scores[i]" so that it subtracts the current number from the next one instead of removing the next number from the current one.
        if jump > best:
            best = jump
    return best

def top_n(students, n):
    """Top N students by final grade (highest first).""" ###loop created to add the names to a separate list so that it is not printing tuples or the grades. N is now passed through when function called instead of always being 2.
    ranked = sorted(
        ((s["name"], final_grade(s["scores"])) for s in students),
        key=lambda pair: pair[1], reverse=True
    )
    for i in ranked:
        ranked_names.append(i[0])

    return ranked_names[:n]

def assignment_averages(students):
    """Average for each assignment index across the class."""
    if not students:
        return []
    num_assignments = len(students[0]["scores"])
    avgs = []
    for i in range(num_assignments):
        total = 0
        for s in students:
            total += s["scores"][i]
        avgs.append(total / len(students))
    return avgs

def pass_rate(students, threshold): ###Threshold will no longer always be 60 and is passed through when the function is called
    """Fraction of students with final >= threshold."""
    passed = 0
    for s in students:
        if final_grade(s["scores"]) >= threshold: ###Was originally just >; updated to >=.
            passed += 1
    return passed / len(students) * 100 ###Multiplying by 100 to get a proper percentage

def summarize():
    print("=== Finals by student (drop-lowest intended) ===")
    for s in STUDENTS:
        print(f"{s['name']:7s} -> {final_grade(s['scores']):.2f}")

    print("\n=== Class median (should average two middles for even class) ===")
    print(f"Median: {class_median(STUDENTS):.2f}")

    print("\n=== Largest single jump per student (should be next - current) ===")
    for s in STUDENTS:
        print(f"{s['name']:7s} -> {largest_single_jump(s['scores']):.2f}")

    print("\n=== Top 2 students (should be highest finals first) ===")
    print(top_n(STUDENTS, n=2))

    print("\n=== Per-assignment averages (should include all 4) ===")
    print(assignment_averages(STUDENTS))

    print("\n=== Pass rate at threshold 60 (>= should pass) ===")
    print(f"Pass rate: {pass_rate(STUDENTS, threshold=60):.2f}%") ###Now displays pass rate as a percentage

if __name__ == "__main__":
    summarize()
