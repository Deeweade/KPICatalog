#!/usr/bin/env bash
# Use this script to test if a given TCP host/port are available

set -e

TIMEOUT=15
STRICT=false
HOST=""
PORT=""

while [[ $# -gt 0 ]]
do
  case "$1" in
    --timeout=*)
    TIMEOUT="${1#*=}"
    shift 1
    ;;
    --strict)
    STRICT=true
    shift 1
    ;;
    *)
    HOST=$1
    PORT=$2
    shift 2
    ;;
  esac
done

if [[ -z "$HOST" || -z "$PORT" ]]; then
  echo "Usage: $0 host port [--timeout=timeout] [--strict]" >&2
  exit 1
fi

wait_for() {
  for i in `seq $TIMEOUT` ; do
    nc -z "$HOST" "$PORT" > /dev/null 2>&1
    result=$?
    if [[ $result -eq 0 ]] ; then
      return 0
    fi
    sleep 1
  done
  return 1
}

if wait_for; then
  exit 0
else
  if [[ "$STRICT" == "true" ]] ; then
    echo "Timeout occurred after waiting $TIMEOUT seconds for $HOST:$PORT"
    exit 1
  else
    echo "Warning: Timeout occurred after waiting $TIMEOUT seconds for $HOST:$PORT"
  fi
fi
