import React from 'react';
import './styles.less';

export const PageWrapper: React.FC = ({ children }) => {
  return <div className="page-wrapper">{children}</div>;
};
