import LabelValuePair from '../DTOs/shared/label-value-pair'

export function toLabelValuePairs(
  values: readonly string[],
  labels: Record<string, string>,
): LabelValuePair[] {
  return values.map((value) => ({
    value,
    label: labels[value] ?? value,
  }))
}
