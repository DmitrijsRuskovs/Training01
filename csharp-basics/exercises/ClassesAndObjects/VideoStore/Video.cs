using System.Collections.Generic;

namespace VideoStore
{
    class Video
    {
        public string Title = "";
        private bool _isCheckedOut = false;
        private double _ratingSum = 0;
        private int _ratingCount = 0;
        public Video(string title)
        {
            this.Title = title;
        }

        public void BeingCheckedOut()
        {
            this._isCheckedOut = true;
        }

        public void BeingReturned()
        {
            this._isCheckedOut = false;
        }

        public void ReceivingRating(double rating)
        {
            this._ratingSum += rating;
            this._ratingCount++;
        }

        public double AverageRating()
        {
            if (this._ratingCount > 0) return this._ratingSum / this._ratingCount;
            else return 0;
        }

        public bool Available()
        {
            return !this._isCheckedOut;
        }
       
        public override string ToString()
        {
            return $"{Title} {AverageRating()} {Available()}";
        }
    }
}
