# 🧮 Day 1 - Pseudo Code Assignments

This document contains the pseudo code solutions for basic programming exercises.

---

## 1️⃣ Check Whether a Number is Even or Odd
```pseudo
START
  INPUT number
  IF number MOD 2 == 0 THEN
      PRINT "Even"
  ELSE
      PRINT "Odd"
  ENDIF
END
```

---

## 2️⃣ Find the Largest of Three Numbers
```pseudo
START
  INPUT a, b, c
  IF a > b AND a > c THEN
      PRINT "a is largest"
  ELSE IF b > a AND b > c THEN
      PRINT "b is largest"
  ELSE
      PRINT "c is largest"
  ENDIF
END
```

---

## 3️⃣ Display the Multiplication Table for Any Number
```pseudo
START
  INPUT number
  FOR i = 1 TO 10 DO
      PRINT number, "x", i, "=", number * i
  ENDFOR
END
```

---

## 4️⃣ Calculate the Sum of First N Natural Numbers
```pseudo
START
  INPUT N
  sum ← 0
  FOR i = 1 TO N DO
      sum ← sum + i
  ENDFOR
  PRINT "Sum =", sum
END
```

---

## 5️⃣ Find the Factorial of a Number
```pseudo
START
  INPUT n
  fact ← 1
  FOR i = 1 TO n DO
      fact ← fact * i
  ENDFOR
  PRINT "Factorial =", fact
END
```

---

## 6️⃣ Calculate the Average and Grade of 5 Subject Marks
```pseudo
START
  INPUT marks1, marks2, marks3, marks4, marks5
  total ← marks1 + marks2 + marks3 + marks4 + marks5
  average ← total / 5

  PRINT "Average =", average

  IF average >= 90 THEN
      PRINT "Grade: A"
  ELSE IF average >= 80 THEN
      PRINT "Grade: B"
  ELSE IF average >= 70 THEN
      PRINT "Grade: C"
  ELSE IF average >= 60 THEN
      PRINT "Grade: D"
  ELSE
      PRINT "Grade: F"
  ENDIF
END
```

---

## 7️⃣ Find the Largest and Smallest Element in an Array
```pseudo
START
  INPUT array of n elements
  largest ← array[0]
  smallest ← array[0]

  FOR i = 1 TO n-1 DO
      IF array[i] > largest THEN
          largest ← array[i]
      ENDIF
      IF array[i] < smallest THEN
          smallest ← array[i]
      ENDIF
  ENDFOR

  PRINT "Largest =", largest
  PRINT "Smallest =", smallest
END
```

---

## 8️⃣ Count How Many Even and Odd Numbers Are in a List
```pseudo
START
  INPUT list of n numbers
  even_count ← 0
  odd_count ← 0

  FOR each number IN list DO
      IF number MOD 2 == 0 THEN
          even_count ← even_count + 1
      ELSE
          odd_count ← odd_count + 1
      ENDIF
  ENDFOR

  PRINT "Even numbers =", even_count
  PRINT "Odd numbers =", odd_count
END
```

---

## 9️⃣ Generate a Pattern Like a Pyramid or Triangle
```pseudo
START
  INPUT n
  FOR i = 1 TO n DO
      FOR j = 1 TO i DO
          PRINT "* "
      ENDFOR
      PRINT newline
  ENDFOR
END
```

**Example Output (n = 4):**
```
*
* *
* * *
* * * *
```

---

## 🔟 Find the Second Largest Number in a List
```pseudo
START
  INPUT list of n numbers
  largest ← second_largest ← -INFINITY

  FOR each number IN list DO
      IF number > largest THEN
          second_largest ← largest
          largest ← number
      ELSE IF number > second_largest AND number != largest THEN
          second_largest ← number
      ENDIF
  ENDFOR

  PRINT "Second largest =", second_largest
END
```

---

## 11️⃣ Find the Sum of Diagonal Elements in a 2D Matrix
```pseudo
START
  INPUT matrix of size n x n
  sum ← 0
  FOR i = 0 TO n-1 DO
      sum ← sum + matrix[i][i]
  ENDFOR
  PRINT "Sum of diagonal elements =", sum
END
```

---

✅ **End of Day 1 Assignments**
